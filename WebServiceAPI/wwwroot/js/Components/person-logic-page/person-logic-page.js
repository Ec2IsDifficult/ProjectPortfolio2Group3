define(["knockout"], function(ko) {
    return function(params) {
        let leftArrow = ko.observable("left-arrow")
        return {
            leftArrow: leftArrow
        }
    }
})