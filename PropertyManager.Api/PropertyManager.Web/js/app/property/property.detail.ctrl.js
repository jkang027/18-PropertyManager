angular.module('app').controller('PropertyDetailController', function ($scope, $stateParams, PropertyResource, $state) {
    $scope.property = PropertyResource.get({ propertyId: $stateParams.id });

    $scope.saveProperty = function () {
        $scope.property.$update(function () {
            alert('Save Successful');
            $state.go('property.grid');
        });
    };
});