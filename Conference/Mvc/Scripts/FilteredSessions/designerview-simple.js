(function () {
    var simpleViewModule = angular.module('designer');
    angular.module('designer').requires.push('sfServices');

    simpleViewModule.controller('SimpleCtrl', ['$scope', '$filter', 'propertyService',
        'serverContext', 'serviceHelper',
    function ($scope, $filter, propertyService,
        serverContext, serviceHelper) {

        $scope.feedback.showLoadingIndicator = true;

        var serviceUrl = serverContext.getRootedUrl('api/default/conferences');
        $scope.conferences = null;
        $scope.speakers = null;

        $scope.getConferences = function (itemId, param, filter) {
            var url = serviceUrl;
            if (itemId && itemId !== serviceHelper.emptyGuid()) {
                url = url + '(' + itemId + ')';
            }

            if (param) {
                url = url + '/' + param;
            }

            if (filter) {
                url = url + '?' + filter;
            }

            return serviceHelper.getResource(url);
        };

        $scope.$watch('conference', function (newVal) {
            if (newVal) {
                $scope.properties.ConferenceId.PropertyValue = newVal.Id;

                $scope.feedback.showLoadingIndicator = true;
                var speakersPromise = $scope.getConferences(newVal.Id, 'Speakers', '$select=Id,FullName').get().$promise;
                speakersPromise.then(function (data) {
                    $scope.speakers = data.value;

                    if ($scope.properties.SpeakerId && $scope.properties.SpeakerId.PropertyValue !== serviceHelper.emptyGuid()) {
                        $scope.speaker = $scope.findById($scope.speakers, $scope.properties.SpeakerId.PropertyValue);
                    }
                })
                .finally(function () {
                    $scope.feedback.showLoadingIndicator = false;
                });
            }
            else if (newVal === null) { // use === to verify newVal is not undefined
                // clear the data if no item is selected
                $scope.properties.ConferenceId.PropertyValue = serviceHelper.emptyGuid();
                $scope.properties.SpeakerId.PropertyValue = serviceHelper.emptyGuid();
                $scope.speakers = null;
                $scope.speaker = null;
            }
        });

        $scope.$watch('speaker', function (newVal) {
            if (newVal) {
                $scope.properties.SpeakerId.PropertyValue = newVal.Id;
            }
            else if (newVal === null) { // use === to verify newVal is not undefined
                $scope.properties.SpeakerId.PropertyValue = serviceHelper.emptyGuid();
                $scope.speaker = null;
            }
        });

        // filters using the $filter
        // returns the first item of the filtered collection
        $scope.findById = function (items, id) {
            var item = $filter('filter')(items, { Id: id })[0];
            return item;
        };

        propertyService.get()
            .then(function (data) {
                if (data) {
                    var getConferencesPromise = $scope.getConferences(null, null, '$select=Id,Title').get().$promise;
                    getConferencesPromise.then(function (data) {
                        $scope.conferences = data.value;

                        if ($scope.properties.ConferenceId && $scope.properties.ConferenceId.PropertyValue !== serviceHelper.emptyGuid()) {
                            $scope.conference = $scope.findById($scope.conferences, $scope.properties.ConferenceId.PropertyValue);
                        } 
                    })
                    .finally(function () {
                        $scope.feedback.showLoadingIndicator = false;
                    });

                    $scope.properties = propertyService.toAssociativeArray(data.Items);
                }
            },
            function (data) {
                $scope.feedback.showError = true;
                if (data)
                    $scope.feedback.errorMessage = data.Detail;
            })
            .finally(function () {
            });
    }]);
})();