# 🐟 Fishing Delivery Notes (FlatDesign)
This repo is a rework of my first WPF project.

## 🪝 How to build
❗warning To protect potentially sensitive information in your connection string, you should move it out of source code.

1. Run the SQL script in MSSQL: https://github.com/spacebagel/FlatDesign/blob/master/FishProductNotesDb.sql
2. Change the connection string in FlatDesignApp.Data -> ProductDeliveryContext class -> OnConfiguring() method

![OnConfiguring](https://github.com/user-attachments/assets/d24473f7-4edc-45d8-a135-f633b3fc4aba)

## 🍥 Screenshots
![LoginWindow](https://github.com/user-attachments/assets/603966e3-26d9-4481-b903-5f87ced789cf)

![WelcomePage](https://github.com/user-attachments/assets/cb793b25-953b-45de-a688-d29318ac4137)

![ViewAndEditPages](https://github.com/user-attachments/assets/ca777f61-f015-4c98-bc11-d3a83866c2b9)

## 🦈 Comparison with the original version

![LoginWindowComparison](https://github.com/user-attachments/assets/7accb8ba-9fc8-48f8-bbe7-53b2e27dc218)

![WelcomePageComparison](https://github.com/user-attachments/assets/7eb5f71f-c400-455d-93dd-59b8ad962ada)

![EditPageComparison](https://github.com/user-attachments/assets/aaba5d32-8e14-4bd6-910d-ff01e519904c)

![ProjectStructureComparison](https://github.com/user-attachments/assets/ff839cad-7759-41e1-b5f7-bcdc6ee90127)

![LoginPageCodeComparison](https://github.com/user-attachments/assets/22f5cff5-9b45-4e2f-90d5-5537709c9934)
