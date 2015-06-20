/// <reference path="../../../typings/angularjs/angular.d.ts"/>
(function() {
	'use strict';

	angular
		.module('dgdaFrontend', [])
	    .service('MainService', MainService);
	
	function MainService($http, serverUrl) {
	    var service = {};
		
		service.getProducts = function(){
			return $http.get(serverUrl + 'api/products');
		};
		
		service.addProducts = function(product){
			return $http.post(serverUrl + 'api/products', product);
		};
		
		service.getProducts = function(oldName, product){
			return $http.put(serverUrl + 'api/products/' + oldName, product);
		};
		
		service.getProducts = function(name){
			return $http.delete(serverUrl + 'api/products/' + name);
		};
	
	    return service;
	}
})();