/**
 * My API - V1
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * Contact: ne bydet
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 *
 */

(function(root, factory) {
  if (typeof define === 'function' && define.amd) {
    // AMD.
    define(['expect.js', process.cwd()+'/src/index'], factory);
  } else if (typeof module === 'object' && module.exports) {
    // CommonJS-like environments that support module.exports, like Node.
    factory(require('expect.js'), require(process.cwd()+'/src/index'));
  } else {
    // Browser globals (root is window)
    factory(root.expect, root.MyApiV1);
  }
}(this, function(expect, MyApiV1) {
  'use strict';

  var instance;

  beforeEach(function() {
    instance = new MyApiV1.AuthorizationApi();
  });

  var getProperty = function(object, getter, property) {
    // Use getter method if present; otherwise, get the property directly.
    if (typeof object[getter] === 'function')
      return object[getter]();
    else
      return object[property];
  }

  var setProperty = function(object, setter, property, value) {
    // Use setter method if present; otherwise, set the property directly.
    if (typeof object[setter] === 'function')
      object[setter](value);
    else
      object[property] = value;
  }

  describe('AuthorizationApi', function() {
    describe('apiAuthorizationLoginPost', function() {
      it('should call apiAuthorizationLoginPost successfully', function(done) {
        //uncomment below and update the code to test apiAuthorizationLoginPost
        //instance.apiAuthorizationLoginPost(function(error) {
        //  if (error) throw error;
        //expect().to.be();
        //});
        done();
      });
    });
    describe('apiAuthorizationRegisterPost', function() {
      it('should call apiAuthorizationRegisterPost successfully', function(done) {
        //uncomment below and update the code to test apiAuthorizationRegisterPost
        //instance.apiAuthorizationRegisterPost(function(error) {
        //  if (error) throw error;
        //expect().to.be();
        //});
        done();
      });
    });
  });

}));