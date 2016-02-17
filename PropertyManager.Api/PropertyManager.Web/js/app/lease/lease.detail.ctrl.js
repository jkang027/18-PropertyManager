angular.module('app').controller('LeaseDetailController', function ($scope, $stateParams, LeaseResource, $state) {
    $scope.lease = LeaseResource.get({ leaseId: $stateParams.id });

    $scope.saveLease = function () {
        $scope.lease.$update(function () {
            alert('Save Successful');
            $state.go('lease.grid');
        });
    };
});