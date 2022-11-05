# MyApiV1.ExpenseTypeApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**createExpenseTypeInCompany**](ExpenseTypeApi.md#createExpenseTypeInCompany) | **POST** /api/Company/{companyId}/ExpenseType | create new expenseType in company
[**deleteExpenseTypeInCompany**](ExpenseTypeApi.md#deleteExpenseTypeInCompany) | **DELETE** /api/Company/{companyId}/ExpenseType/{expenseTypeId} | delete expense type in company
[**getEpxensTypesInCompany**](ExpenseTypeApi.md#getEpxensTypesInCompany) | **GET** /api/Company/{companyId}/ExpenseType | get expense types in company
[**getExpenseTypeInCompany**](ExpenseTypeApi.md#getExpenseTypeInCompany) | **GET** /api/Company/{companyId}/ExpenseType/{expenseTypeId} | get expense type in company by id
[**updateExpenseType**](ExpenseTypeApi.md#updateExpenseType) | **PUT** /api/Company/{companyId}/ExpenseType/{expenseTypeId} | can change name,limit, description



## createExpenseTypeInCompany

> createExpenseTypeInCompany(companyId, opts)

create new expenseType in company

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.ExpenseTypeApi();
let companyId = 56; // Number | 
let opts = {
  'expenseType': new MyApiV1.ExpenseType() // ExpenseType | 
};
apiInstance.createExpenseTypeInCompany(companyId, opts, (error, data, response) => {
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
 **expenseType** | [**ExpenseType**](ExpenseType.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: Not defined


## deleteExpenseTypeInCompany

> deleteExpenseTypeInCompany(companyId, expenseTypeId)

delete expense type in company

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.ExpenseTypeApi();
let companyId = 56; // Number | 
let expenseTypeId = 56; // Number | 
apiInstance.deleteExpenseTypeInCompany(companyId, expenseTypeId, (error, data, response) => {
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
 **expenseTypeId** | **Number**|  | 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined


## getEpxensTypesInCompany

> [ExpenseType] getEpxensTypesInCompany(companyId)

get expense types in company

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.ExpenseTypeApi();
let companyId = 56; // Number | 
apiInstance.getEpxensTypesInCompany(companyId, (error, data, response) => {
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

### Return type

[**[ExpenseType]**](ExpenseType.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## getExpenseTypeInCompany

> ExpenseType getExpenseTypeInCompany(companyId, expenseTypeId)

get expense type in company by id

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.ExpenseTypeApi();
let companyId = 56; // Number | 
let expenseTypeId = 56; // Number | 
apiInstance.getExpenseTypeInCompany(companyId, expenseTypeId, (error, data, response) => {
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
 **expenseTypeId** | **Number**|  | 

### Return type

[**ExpenseType**](ExpenseType.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## updateExpenseType

> updateExpenseType(companyId, expenseTypeId, opts)

can change name,limit, description

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.ExpenseTypeApi();
let companyId = 56; // Number | 
let expenseTypeId = 56; // Number | 
let opts = {
  'expenseType': new MyApiV1.ExpenseType() // ExpenseType | 
};
apiInstance.updateExpenseType(companyId, expenseTypeId, opts, (error, data, response) => {
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
 **expenseTypeId** | **Number**|  | 
 **expenseType** | [**ExpenseType**](ExpenseType.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, application/*+json
- **Accept**: Not defined

