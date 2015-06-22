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
    vm.productToAdd = {Name: null, Description: null, Price: null, InStock: false};

    activate();

    function activate() {
      getProducts();
    }
    
    function getProducts() {
      MainService.getProducts()
        .success(function(data){
          vm.products = data.map(function(cur){
            return {
              Name: cur.Name, 
              OldName: cur.Name, 
              Description: cur.Description, 
              Price: cur.Price,
              InStock: cur.InStock
              }
          });
        })
        .error(function(data, status){
          showToastr("Unable to get products.", "Failed");
        });
    }
    
    vm.addProduct = function addProduct(){
      MainService.addProduct(vm.productToAdd)
        .success(function(){
          showToastr('Product added.', "Success");
          vm.productToAdd = {Name: null, Description: null, Price: null, InStock: false};
          getProducts();
        })
        .error(function(error){
          showToastr("Unable to add product.", "Failed");
        });
    };
    
    vm.updateProduct = function updateProduct(product){
      MainService.updateProduct(product.OldName, product)
        .success(function(){
          showToastr('Product updated.', "Success");
          getProducts();
        })
        .error(function(error){
          showToastr("Unable to update product.", "Failed");
        });
    };
    
    vm.deleteProduct = function deleteProduct(name){
      MainService.deleteProduct(name)
        .success(function(){
          showToastr('Product deleted.', "Success");
          getProducts();
        })
        .error(function(error){
          showToastr("Unable to delete product.", "Failed");
        });
    };

    function showToastr(message, title) {
      toastr.info(message, title);
    }
  }
})();
