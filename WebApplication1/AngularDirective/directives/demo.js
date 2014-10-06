Application.directive('mysample', function () {
    return {

        link: function (scope, element, attrs, controller) {

            element.on('click', function () {

                alert("hello world");

            });

        }


    }
});