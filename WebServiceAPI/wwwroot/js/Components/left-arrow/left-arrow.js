define(["viewmodel"], function(vm) {
    return function(params) {
        let goToTitleLogicView = () => {
            vm.changeContent(vm.componentItems.find(item => item.component === params));
        }
        
        return {
            goToTitleLogicView: goToTitleLogicView
        }
    }
})