# AllTheBeansApp

## Description
AllTheBeansApp is my first web application built using C# and ASP.NET Core that shows different types of beans. It features a "Bean of the Day" section, a list of all available beans with information about each bean, and a cart feature, where customers can add and remove beans.

I kept the design functional, but simple, as the specification mentioned that design skills would not be judged.

As far as the task itself, I had a great time learning more about C# and building on my knowledge of HTML, CSS & JS within the .NET framework - it does seem to be an extremely tidy and efficient system.

## Requirements
- .NET SDK (version 5.0 or later)
- Newtonsoft.Json (version 13.0.3)
- Node.js and npm (for managing client-side packages)

## Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/xaatu/AllTheBeansApp
    ```
2. Navigate to the project directory:
    ```bash
    cd AllTheBeansApp
    ```
3. Install the dependencies:
    ```bash
    npm install
    ```

## Project Structure
- **Controllers**: Contains the logic for handling HTTP requests (e.g., `HomeController.cs`).
- **Models**: Contains the data models and business logic (e.g., `BeansRepository.cs`, `Bean.cs`).
- **Views**: Contains the Razor views for rendering HTML (e.g., `_Layout.cshtml`, `Index.cshtml`).
- **wwwroot**: Contains static files like CSS, JavaScript, and images.

## Features
- **Bean of the Day**: Displays a featured bean based on the current day of the week.
- **All Beans**: Lists all available beans with detailed information.
- **Cart**: Contains all the beans customers have added to cart, alongside item price and total price.
- **Navigation**: Easy navigation between different sections of the app.
- **Responsive Design**: Uses Bootstrap for a responsive and modern UI.



## How to run

1. Build:
    ```bash
    dotnet build
    ```
2. Run:
    ```bash
    dotnet run
    ```



3. (optional) for Hot Reloads ((has been extremely useful while building!)):
    ```bash
    dotnet watch run
    ```


## Contact
For any inquiries or feedback, please contact [sandy.quigley95@gmail.com].