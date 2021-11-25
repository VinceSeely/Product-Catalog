# Product Catalog

This application allows you to add and update a product. You can allso see the history of all the products or request a list of all the products. 

## Running the Application


To run the application you will need to have docker installed or to setup the database connections yourself. Everything should just work if run in the docker containers. 

```
docker-compose up
```

To run the tests for this project

``` 
dotnet test 
```


## Sample Calls

* GET api/Product
  * returns
  ```
  [
    {
        "id": 1,
        "name": "new product",
        "price": 4.199999809265137
    },
    {
        "id": 2,
        "name": "new product1",
        "price": 4.199999809265137
    },
    {
        "id": 3,
        "name": "new product 2",
        "price": 4.199999809265137
    },
    {
        "id": 4,
        "name": "new product 3",
        "price": 4.199999809265137
    },
    {
        "id": 5,
        "name": "new product 5",
        "price": 5.400000095367432
    }
  ]
  ```
* GET api/Product/history/{ProductId}
  * returns a list of product history information
  ```
  [
    {
        "productHistoryId": 6,
        "productId": 5,
        "newPrice": 4.199999809265137,
        "newName": "Name 1",
        "updateTime": "2021-11-25T01:06:12"
    },
    {
        "productHistoryId": 7,
        "productId": 5,
        "newPrice": 4.400000095367432,
        "newName": "Name 2",
        "updateTime": "2021-11-25T01:08:12"
    },
    {
        "productHistoryId": 8,
        "productId": 5,
        "newPrice": 5.400000095367432,
        "newName": "Name 3",
        "updateTime": "2021-11-25T01:09:12"
    }
  ]
  ```
* POST api/Product/update
    This can update the product name and price
```
    {
        "id": 1,
        "name": "new product",
        "price": 4.199999809265137
    }
```

* PUT api/Product/add
```
    {
        "name": "new product",
        "price": 4.199999809265137
    }
```

* GET api/Product/{ProductId}

  * returns 
```
    {
        "id": 1,
        "name": "new product",
        "price": 4.199999809265137
    }
```