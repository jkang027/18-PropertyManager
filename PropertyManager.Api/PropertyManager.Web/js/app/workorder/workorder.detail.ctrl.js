angular.module('app').controller('WorkOrderDetailController', function ($scope, $stateParams, WorkOrderResource, $state) {
    $scope.workOrder = WorkOrderResource.get({ workOrderId: $stateParams.id });

    $scope.saveWorkOrder = function () {
        $scope.workOrder.$update(function () {
            alert('Save Successful');
            $state.go('workOrder.grid');
        });
    };
});