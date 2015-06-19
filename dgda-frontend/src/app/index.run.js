(function() {
  'use strict';

  angular
    .module('dgdaFrontend')
    .run(runBlock);

  /** @ngInject */
  function runBlock($log) {

    $log.debug('runBlock end');
  }

})();
