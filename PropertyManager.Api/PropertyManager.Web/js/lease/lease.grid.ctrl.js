angular.module('app').controller('LeaseGridController', function ($scope, LeaseResource) {

    function activate() {
        $scope.leases = LeaseResource.query();
    }

    $scope.deleteLease = function (lease) {
        lease.$remove(function () {
            alert('Lease Removed');
            activate();
        });
    };

    activate();

});