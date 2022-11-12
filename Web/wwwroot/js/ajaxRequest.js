

import "../lib/jsApiClient/src/index.js";

let clientInstance = new ApiClient("http://localhost:49151");

let companyApi = new CompanyApi(clientInstance);

companyApi.getCompanyes((error, data, response) => {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
});