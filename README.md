## 🧪 Warehouse Box Analysis – QA-Oriented Project (C#)

This project is a C# console application developed in Visual Studio, focused on testing and validating warehouse box data processing logic.

### 🎯 Project Goal

The goal of this project is to simulate real-world data validation and analysis scenarios by:

Verifying correctness of input data

Testing business logic related to box properties

Validating calculations and filtering behavior

### 🛠 Tech Stack

C#

.NET Console Application

Visual Studio

### 📂 Test Data

Test data is stored in a .txt file and represents warehouse box records with the following attributes:

- Material type

- Length, width, height

- Maximum weight capacity

- Maximum stacking limit

### 🔍 QA Focus Areas

✅ Data Validation

Verifies that input data is correctly read and parsed from file

Ensures all required fields are present and properly formatted

✅ Functional Testing

Confirms correct identification of the box with the maximum weight capacity

Validates shelf height calculation logic based on box dimensions

Ensures correct handling of stacking constraints

✅ Filtering & Sorting Logic

Tests filtering of boxes by material type

Verifies sorting by maximum weight capacity

Ensures filtered results are accurate and complete

✅ Output Verification

Validates that all results are correctly displayed in the console

Confirms consistency between input data and output results

🧪 Example Test Scenarios

Validate correct parsing of box data from input file

Verify maximum weight box is correctly identified

Check if shelf height calculation is accurate

Test filtering by different material types

Confirm sorting order is correct

🖥 Output

All test results and processed data are displayed in the console, allowing easy verification of:

Full dataset

Filtered results

Calculated values
