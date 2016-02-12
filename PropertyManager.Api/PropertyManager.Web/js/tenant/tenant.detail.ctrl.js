angular.module('app').controller('TenantDetailController', function ($scope, $stateParams, TenantResource, $state) {
    $scope.tenant = TenantResource.get({ tenantId: $stateParams.id });

    $scope.saveTenant = function () {
        $scope.tenant.$update(function () {
            alert('Save Successful');
            $state.go('tenant.grid');
        });
    };
});