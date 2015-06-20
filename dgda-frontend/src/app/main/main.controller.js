/// <reference path="../../../typings/angularjs/angular.d.ts"/>
(function() {
  'use strict';

  angular
    .module('dgdaFrontend')
    .controller('MainController', MainController);

  /** @ngInject */
  function MainController(MainService, toastr) {    
    var vm = this;

    vm.products = [];
    vm.error = null;

    activate();

    function activate() {
      getProducts();
    }
    
    function getProducts() {
      MainService.getProducts()
        .then(function(products){
          vm.products = products;
        })
        .error(function(error){
          vm.error = error;
        });
    }
    
    vm.addProduct = function addProduct(product){
      MainService.addProduct(product)
        .then(function(){
          showToastr('Product added.');
        })
        .error(function(error){
          vm.error = error;
        });
    };
    
    vm.updateProduct = function updateProduct(oldName, product){
      MainService.updateProduct(product)
        .then(function(){
          showToastr('Product updated.');
        })
        .error(function(error){
          vm.error = error;
        });
    };
    
    vm.deleteProduct = function deleteProduct(name){
      MainService.updateProduct(name)
        .then(function(){
          showToastr('Product deleted.');
        })
        .error(function(error){
          vm.error = error;
        });
    };

    function showToastr(message) {
      toastr.info(message);
    }
  }
})();
