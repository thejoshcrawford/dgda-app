/// <reference path="../../../typings/angularjs/angular.d.ts"/>
(function() {
	'use strict';

	angular
		.module('dgdaFrontend')
	    .service('MainService', MainService);
	
	function MainService($http, serverUrl) {
	    var service = {};
		
		service.getProducts = function(){
			return $http.get(serverUrl + 'api/products/');
		};
		
		service.addProduct = function(product){
			return $http.post(serverUrl + 'api/products', product);
		};
		
		service.updateProduct = function(oldName, product){
			return $http.put(serverUrl + 'api/products/' + oldName, product);
		};
		
		service.deleteProduct = function(name){
			return $http.delete(serverUrl + 'api/products/' + name);
		};
	
	    return service;
	}
})();