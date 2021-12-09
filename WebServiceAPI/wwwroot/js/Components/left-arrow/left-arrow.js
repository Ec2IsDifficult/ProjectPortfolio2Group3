define(["viewmodel"], function(vm) {
    return function(params) {
        
        let goToTitleLogicView = () => {
            vm.currentView("title-logic-page");
            vm.currentParams("title-logic-page")
            console.log("Hello world");
        }
        
        return {
            goToTitleLogicView: goToTitleLogicView
        }
    }
})