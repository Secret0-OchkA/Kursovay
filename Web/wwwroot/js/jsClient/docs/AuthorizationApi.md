# MyApiV1.AuthorizationApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**apiAuthorizationLoginPost**](AuthorizationApi.md#apiAuthorizationLoginPost) | **POST** /api/Authorization/Login | generation jwt token on 1 day
[**apiAuthorizationRegisterPost**](AuthorizationApi.md#apiAuthorizationRegisterPost) | **POST** /api/Authorization/Register | Register new Account



## apiAuthorizationLoginPost

> String apiAuthorizationLoginPost(opts)

generation jwt token on 1 day

### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.AuthorizationApi();
let opts = {
  'email': "email_example", // String | 
  'password': "password_example" // String | 
};
apiInstance.apiAuthorizationLoginPost(opts, (error, data, response) => {
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
 **email** | **String**|  | [optional] 
 **password** | **String**|  | [optional] 

### Return type

**String**

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json


## apiAuthorizationRegisterPost

> apiAuthorizationRegisterPost(opts)

Register new Account

### Example

```javascript
import MyApiV1 from 'my_api_v1';
let defaultClient = MyApiV1.ApiClient.instance;
// Configure Bearer access token for authorization: Bearer
let Bearer = defaultClient.authentications['Bearer'];
Bearer.accessToken = "YOUR ACCESS TOKEN"

let apiInstance = new MyApiV1.AuthorizationApi();
let opts = {
  'name': "name_example", // String | 
  'login': "login_example", // String | 
  'password': "password_example", // String | 
  'roleName': "roleName_example" // String | 
};
apiInstance.apiAuthorizationRegisterPost(opts, (error, data, response) => {
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
 **name** | **String**|  | [optional] 
 **login** | **String**|  | [optional] 
 **password** | **String**|  | [optional] 
 **roleName** | **String**|  | [optional] 

### Return type

null (empty response body)

### Authorization

[Bearer](../README.md#Bearer)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

