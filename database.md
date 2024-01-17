## Product Table

| Column Name | Data Type | Nullable | Default |
|-------------|-----------|----------|---------|
| product_id  | int       | NO       | NULL    |
| product_name| varchar   | YES      | NULL    |
| category_id | int       | YES      | NULL    |
| image_url   | varchar   | YES      | NULL    |
| price       | decimal   | YES      | NULL    |
| stock       | int       | YES      | NULL    |

## Cart Table

| Column Name | Data Type | Nullable | Default |
|-------------|-----------|----------|---------|
| id          | int       | NO       | NULL    |
| customerid  | int       | YES      | NULL    |
| product_id  | int       | YES      | NULL    |
| quantity    | int       | YES      | NULL    |
| total_price | decimal   | YES      | NULL    |

## Category Table

| Column Name  | Data Type | Nullable | Default |
|--------------|-----------|----------|---------|
| category_id  | int       | NO       | NULL    |
| category_name| varchar   | YES      | NULL    |
| image_url    | varchar   | YES      | NULL    |

## Customers Table

| Column Name | Data Type | Nullable | Default |
|-------------|-----------|----------|---------|
| CustomerId  | int       | NO       | NULL    |
| FirstName   | varchar   | YES      | NULL    |
| LastName    | varchar   | YES      | NULL    |
| Email       | varchar   | YES      | NULL    |
| Password    | varchar   | YES      | NULL    |
| Address     | varchar   | YES      | NULL    |
| City        | varchar   | YES      | NULL    |
| IsAdmin     | bit       | YES      | NULL    |

## Order Table

| Column Name | Data Type | Nullable | Default |
|-------------|-----------|----------|---------|
| order_id    | int       | NO       | NULL    |
| customer_id | int       | YES      | NULL    |
| product_id  | int       | YES      | NULL    |
| address     | varchar   | YES      | NULL    |
| quantity    | int       | YES      | NULL    |
| total_price | decimal   | YES      | NULL    |
