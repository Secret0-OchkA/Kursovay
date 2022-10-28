# MyApiV1.RoleApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiRoleGet**](RoleApi.md#apiRoleGet) | **GET** /api/Role | 
[**apiRoleRoleIdGet**](RoleApi.md#apiRoleRoleIdGet) | **GET** /api/Role/{roleId} | 



## apiRoleGet

> [Role] apiRoleGet()



### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.RoleApi();
apiInstance.apiRoleGet((error, data, response) => {
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

[**[Role]**](Role.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json


## apiRoleRoleIdGet

> Role apiRoleRoleIdGet(roleId)



### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.RoleApi();
let roleId = 56; // Number | 
apiInstance.apiRoleRoleIdGet(roleId, (error, data, response) => {
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
 **roleId** | **Number**|  | 

### Return type

[**Role**](Role.md)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: text/plain, application/json, text/json

