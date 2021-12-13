define(["viewmodel"], function(vm) {
    return function(params) {
        let goToPersonLogicPage = () => {
            vm.changeContent(vm.componentItems.find(item => item.component === params));
        }
        
        
        return {
            goToPersonLogicPage:goToPersonLogicPage
        }
    }
})