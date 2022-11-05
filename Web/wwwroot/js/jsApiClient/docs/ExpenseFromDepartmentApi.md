# MyApiV1.ExpenseFromDepartmentApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**getExpenseInDeparment**](ExpenseFromDepartmentApi.md#getExpenseInDeparment) | **GET** /api/Company/{companyId}/Department/{departmnetId}/ExpenseFromDepartment/{expenseId} | get expense in department by id
[**getExpesesInDepartment**](ExpenseFromDepartmentApi.md#getExpesesInDepartment) | **GET** /api/Company/{companyId}/Department/{departmnetId}/ExpenseFromDepartment | get expenses in department



## getExpenseInDeparment

> Expense getExpenseInDeparment(companyId, departmnetId, expenseId)

get expense in department by id

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.ExpenseFromDepartmentApi();
let companyId = 56; // Number | 
let departmnetId = 56; // Number | 
let expenseId = 56; // Number | 
apiInstance.getExpenseInDeparment(companyId, departmnetId, expenseId, (error, data, response) => {
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
 **expenseId** | **Number**|  | 

### Return type

[**Expense**](Expense.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## getExpesesInDepartment

> [Expense] getExpesesInDepartment(companyId, departmnetId)

get expenses in department

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.ExpenseFromDepartmentApi();
let companyId = 56; // Number | 
let departmnetId = 56; // Number | 
apiInstance.getExpesesInDepartment(companyId, departmnetId, (error, data, response) => {
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

[**[Expense]**](Expense.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

