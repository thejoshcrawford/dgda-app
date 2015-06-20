/* global malarkey:false, toastr:false, moment:false */
(function() {
  'use strict';

  angular
    .module('dgdaFrontend')
    .constant('malarkey', malarkey)
    .constant('toastr', toastr)
    .constant('moment', moment)
    .constant('serverUrl', 'http://localhost:43409/');
})();
