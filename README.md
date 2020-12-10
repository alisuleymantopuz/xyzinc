#### XYZ Inc.
An example implementation of onion architecture for rest api with jwt authentication.


#### API
Auth API: /auth
    Create Token: /auth/token

request    
```json
{
    "username":"test",
    "email":"test@test.com",
    "password":"test"
}
```
response 
```json
 {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InRlc3QiLCJlbWFpbCI6InRlc3RAdGVzdC5jb20iLCJuYmYiOjE2MDc1NDk1NjUsImV4cCI6MTYwNzU0OTYyNSwiaWF0IjoxNjA3NTQ5NTY1LCJpc3MiOiJYWVpJbmMiLCJhdWQiOiJYWVhJbmMifQ.MzVwaQFXdZYagej7FxWgB1jyEJjKb7PZwkOBQTyIIZI",
    "message": "Success"
}
```

Order API: /order
Create Order: /order/create

request    
```json
{
  "orderNumber": "test",
  "userId": "test",
  "payableAmount": 12.2,
  "paymentGateway": "Visa",
  "optionalDescription": "Optional description"
}
```
response 
```json
{
    "receipt": {
        "creationDate": "2020-12-09T21:35:34.6047229Z",
        "orderNumber": "test",
        "status": "Success"
    }
}
```

#### Swagger UI
/swagger/ui

#### Unit Tests
xUnit unit tests

#### Integration Tests
xUnit integration tess for APIs

