﻿angular.module('app').factory('AuthenticationService', function ($http, $q, localStorageService, apiUrl) {
    var state = {
        authorized: false
    };

    function initialize() {
        var token = localStorageService.get('token');

        if (token) {
            state.authorized = true;
        }
    }

    function register(registration) {
        return $http.post(apiUrl + '/accounts/register', registration).then(
            function (response) {
                return response;
            }
        );
    }

    function login(loginData) {
        var data = 'grant_type=password&username=' + loginData.username + '&password=' + loginData.password;

        var deferred = $q.defer();

        $http.post(apiUrl + '/token', data, {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        }).success(function (response) {
            localStorageService.set('token', {
                token: response.access_token
            });

            state.authorized = true;

            deferred.resolve(response);
        }).error(function (err, status) {
            logout();

            deferred.reject(err);
        });

        return deferred.promise;
    }

    function logout() {
        localStorageService.remove('token');

        state.authorized = false;
    }

    return {
        state: state,
        initialize: initialize,
        register: register,
        login: login,
        logout: logout
    };
});