angular.module('app').factory('WorkOrderResource', function (apiUrl, $resource) {
    return $resource(apiUrl + '/workOrders/:workOrderId', { workOrderId: '@WorkOrderId' },
    {
        'update': {
            method: 'PUT'
        }
    });
});