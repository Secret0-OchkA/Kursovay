# MyApiV1.EmployeeApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createEmployee**](EmployeeApi.md#createEmployee) | **POST** /api/Employee | 
[**deleteEmployee**](EmployeeApi.md#deleteEmployee) | **DELETE** /api/Employee/{id} | 
[**getEmployee**](EmployeeApi.md#getEmployee) | **GET** /api/Employee/{id} | 
[**getEmployees**](EmployeeApi.md#getEmployees) | **GET** /api/Employee | 



## createEmployee

> createEmployee(opts)



### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.EmployeeApi();
let opts = {
  'employee': new MyApiV1.Employee() // Employee | 
};
apiInstance.createEmployee(opts, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **employee** | [**Employee**](Employee.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: Not defined


## deleteEmployee

> deleteEmployee(id)



### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.EmployeeApi();
let id = 56; // Number | 
apiInstance.deleteEmployee(id, (error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **Number**|  | 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined


## getEmployee

> Employee getEmployee(id)



### Example

```javascript
import MyApiV1 from 'my_api_v1';

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

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## getEmployees

> [Employee] getEmployees()



### Example

```javascript
import MyApiV1 from 'my_api_v1';

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

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

