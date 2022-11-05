# MyApiV1.EmployeeFromDepartmentApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**dismissEmployee**](EmployeeFromDepartmentApi.md#dismissEmployee) | **DELETE** /api/Company/{companyId}/Department/{departmnetId}/EmployeeFromDepartment/{employeeId} | remove employee from department in company
[**getEmployeeInDepartment**](EmployeeFromDepartmentApi.md#getEmployeeInDepartment) | **GET** /api/Company/{companyId}/Department/{departmnetId}/EmployeeFromDepartment/{employeeId} | get employee in department in company by id
[**getEmployeesInDepartment**](EmployeeFromDepartmentApi.md#getEmployeesInDepartment) | **GET** /api/Company/{companyId}/Department/{departmnetId}/EmployeeFromDepartment | get employees in department in company
[**hireEmployee**](EmployeeFromDepartmentApi.md#hireEmployee) | **POST** /api/Company/{companyId}/Department/{departmnetId}/EmployeeFromDepartment/{employeeId} | add epmployee to department



## dismissEmployee

> Employee dismissEmployee(companyId, departmnetId, employeeId)

remove employee from department in company

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.EmployeeFromDepartmentApi();
let companyId = 56; // Number | 
let departmnetId = 56; // Number | 
let employeeId = 56; // Number | 
apiInstance.dismissEmployee(companyId, departmnetId, employeeId, (error, data, response) => {
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
 **companyId** | **Number**|  | 
 **departmnetId** | **Number**|  | 
 **employeeId** | **Number**|  | 

### Return type

[**Employee**](Employee.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## getEmployeeInDepartment

> Employee getEmployeeInDepartment(companyId, departmnetId, employeeId)

get employee in department in company by id

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.EmployeeFromDepartmentApi();
let companyId = 56; // Number | 
let departmnetId = 56; // Number | 
let employeeId = 56; // Number | 
apiInstance.getEmployeeInDepartment(companyId, departmnetId, employeeId, (error, data, response) => {
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
 **companyId** | **Number**|  | 
 **departmnetId** | **Number**|  | 
 **employeeId** | **Number**|  | 

### Return type

[**Employee**](Employee.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## getEmployeesInDepartment

> [Employee] getEmployeesInDepartment(companyId, departmnetId)

get employees in department in company

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.EmployeeFromDepartmentApi();
let companyId = 56; // Number | 
let departmnetId = 56; // Number | 
apiInstance.getEmployeesInDepartment(companyId, departmnetId, (error, data, response) => {
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
 **companyId** | **Number**|  | 
 **departmnetId** | **Number**|  | 

### Return type

[**[Employee]**](Employee.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## hireEmployee

> hireEmployee(companyId, departmnetId, employeeId)

add epmployee to department

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.EmployeeFromDepartmentApi();
let companyId = 56; // Number | 
let departmnetId = 56; // Number | 
let employeeId = 56; // Number | 
apiInstance.hireEmployee(companyId, departmnetId, employeeId, (error, data, response) => {
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
 **companyId** | **Number**|  | 
 **departmnetId** | **Number**|  | 
 **employeeId** | **Number**|  | 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

