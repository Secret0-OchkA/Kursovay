# MyApiV1.EmployeeApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**getEmployee**](EmployeeApi.md#getEmployee) | **GET** /api/Employee/{id} | 
[**getEmployees**](EmployeeApi.md#getEmployees) | **GET** /api/Employee | 



## getEmployee

> Employee getEmployee(id)



### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.EmployeeApi();
let id = 56; // Number | 
apiInstance.getEmployee(id, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **Number**|  | 

### Return type

[**Employee**](Employee.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## getEmployees

> [Employee] getEmployees()



### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.EmployeeApi();
apiInstance.getEmployees((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**[Employee]**](Employee.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

