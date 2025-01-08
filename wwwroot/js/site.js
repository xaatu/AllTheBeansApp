document.addEventListener('DOMContentLoaded', function() {
  // Toggle for navbar expand
  var navbarToggler = document.querySelector('.navbar-toggler');
  navbarToggler.addEventListener('click', function() {
    document.body.classList.toggle('navbar-expanded');
  });

  // Initialise cart (localStorage)
  var cart = JSON.parse(localStorage.getItem('cart')) || [];
  var cartIcon = document.createElement('div');
  cartIcon.className = 'cart-icon';
  cartIcon.innerHTML = '🛒';
  document.body.appendChild(cartIcon);

  // Cart icon leads to Cart page
  cartIcon.addEventListener('click', function() {
    window.location.href = '/cart';
  });

  // Add to cart functionality for each bean (Bean of the day page)
  document.querySelectorAll('.bean-of-the-day').forEach(function(bean) {
    var quantityInput = document.createElement('input');
    quantityInput.type = 'number';
    quantityInput.value = 1;
    quantityInput.min = 1;
    quantityInput.className = 'bean-quantity-input';
    bean.appendChild(quantityInput);

    var addToCartButton = document.createElement('button');
    addToCartButton.className = 'add-to-cart-button';
    addToCartButton.innerText = 'Add to Cart';
    bean.appendChild(addToCartButton);

    addToCartButton.addEventListener('click', function() {
      var beanName = bean.querySelector('h2').innerText;
      var quantity = parseInt(quantityInput.value);

      fetch(`/api/beans/price?name=${encodeURIComponent(beanName)}`)
        .then(response => response.json())
        .then(data => {
          var price = data.price;
          var existingItem = cart.find(item => item.name === beanName);
          if (existingItem) {
            existingItem.quantity += quantity;
          } else {
            cart.push({ name: beanName, quantity: quantity, price: price });
          }
          localStorage.setItem('cart', JSON.stringify(cart));
          alert(quantity + ' ' + beanName + '(s) added to cart');
        });
    });
  });

  // Total price 
  if (window.location.pathname === '/cart') {
    var cartPage = document.createElement('div');
    cartPage.className = 'cart-page';
    document.body.appendChild(cartPage);

    var totalPrice = 0;

    cart.forEach(function(item) {
      var cartItem = document.createElement('div');
      cartItem.className = 'cart-item';
      cartItem.innerHTML = `
        <span>${item.name}</span>
        <input type="number" value="${item.quantity}" min="1" class="cart-quantity" data-name="${item.name}">
        <span>£${(item.price * item.quantity).toFixed(2)}</span>
        <button class="remove-from-cart-button" data-name="${item.name}">Remove</button>
      `;
      cartPage.appendChild(cartItem);
      totalPrice += item.price * item.quantity;
    });

    var totalPriceElement = document.createElement('div');
    totalPriceElement.className = 'total-price';
    totalPriceElement.innerHTML = `Total Price: £${totalPrice.toFixed(2)}`;
    cartPage.appendChild(totalPriceElement);

    // Update item quantity (cart)
    document.querySelectorAll('.cart-quantity').forEach(function(input) {
      input.addEventListener('change', function() {
        var beanName = this.getAttribute('data-name');
        var newQuantity = parseInt(this.value);
        var item = cart.find(item => item.name === beanName);
        if (item) {
          item.quantity = newQuantity;
          localStorage.setItem('cart', JSON.stringify(cart));
          location.reload(); // Reloads to update price
        }
      });
    });

    // Remove item from cart
    document.querySelectorAll('.remove-from-cart-button').forEach(function(button) {
      button.addEventListener('click', function() {
        var beanName = this.getAttribute('data-name');
        cart = cart.filter(item => item.name !== beanName);
        localStorage.setItem('cart', JSON.stringify(cart));
        location.reload(); // Reloads to update
      });
    });
  }

});
