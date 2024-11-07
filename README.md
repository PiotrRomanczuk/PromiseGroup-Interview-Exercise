# PromiseGroup Interview Exercise

This is a console application that allows users to place orders. The application includes business logic for products, order items, and orders. It supports adding products, removing products, displaying the order value, and exiting the application.

## Features

- Add product to order
- Delete product from order
- Check products in order
- Save order in the database
- Check previous orders from the database
- Display current date and time
- Display welcome message

## Products

The available products are:

1. Laptop: 2500 PLN
2. Keyboard: 120 PLN
3. Mouse: 90 PLN
4. Display: 1000 PLN
5. Debugging Duck: 66 PLN

## Discount Logic

- 10% discount on the second cheapest product if there are more than one product in the order.
- 20% discount on the third cheapest product if there are more than two products in the order.
- 5% discount on the entire order if the total order value exceeds 5000 PLN.

## Requirements

- .NET 8.0
- SQLite

## Getting Started

1. Clone the repository:

    ```sh
    git clone https://github.com/PiotrRomanczuk/PromiseGroup-Interview-Exercise
    ```

2. Navigate to the project directory:

    ```sh
    cd PromiseExercise_App
    ```

3. Build the project:

    ```sh
    dotnet build
    ```

4. Run the application:

    ```sh
    dotnet run
    ```

## Project Structure

- `PromiseExercise_App/`: Main application code
  - `AppInitializer.cs`: Initializes the application and sets up dependencies
  - `DB/`: Database-related classes and context
  - `Displays/`: Classes for displaying information to the user
  - `Handlers/`: Classes for handling various operations
  - `Order/`: Classes related to order processing
  - `Product/`: Classes related to products
  - `Program.cs`: Main entry point of the application
- `PromiseExercise_Test/`: Unit tests for the application
- `README.md`: Project documentation
- `Requirements.md`: Project requirements

## Usage

1. Run the application.
2. Follow the on-screen instructions to add, delete, or check products in your order.
3. Save your order to the database or check previous orders from the database.
4. Exit the application by selecting the appropriate option.

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Create a new Pull Request.

## License

This project is licensed under the MIT License.
