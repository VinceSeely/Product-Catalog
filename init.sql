
CREATE DATABASE IF NOT EXISTS product_catalog;

USE product_catalog;

CREATE TABLE IF NOT EXISTS Product(
    Id INT NOT NULL AUTO_INCREMENT,
    Name VARCHAR(255),
    Price FLOAT(2),
    PRIMARY KEY(Id)
);

CREATE TABLE ProductHistory(
    ProductHistoryId INT NOT NULL AUTO_INCREMENT,
    ProductId INT,
    NewPrice  FLOAT(2),
    UpdateTime DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY(ProductHistoryId)
);