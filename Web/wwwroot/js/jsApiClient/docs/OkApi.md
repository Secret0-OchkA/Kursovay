# MyApiV1.OkApi

All URIs are relative to *http://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**checkConnectToApi**](OkApi.md#checkConnectToApi) | **GET** /api/Ok | for check connect



## checkConnectToApi

> checkConnectToApi()

for check connect

### Example

```javascript
import MyApiV1 from 'my_api_v1';

let apiInstance = new MyApiV1.OkApi();
apiInstance.checkConnectToApi((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
});
```

### Parameters

This endpoint does not need any parameter.

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: Not defined

