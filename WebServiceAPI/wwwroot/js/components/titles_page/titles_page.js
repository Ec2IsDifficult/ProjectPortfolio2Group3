define(["knockout", "dataservice"],
    function (ko, ds) {

        let selectedTitle = ko.observable('tt1954874');
        
        let titleRating = ko.observable();
        
        let getTitleRating = () => {
            ds.getTitleRating(selectedTitle(), function (data) {
                console.log(data);
                titleRating(data);
            })
        };

        let crew = ko.observable([]);
        let getTitleCrew = async () => {
            await ds.getCrew(selectedTitle(), function (data) {
                console.log(data.crew)
                crew(data.crew);
            })
        };

        let title = ko.observable();
        //titles viewmodels
        let getSingleTitle = async () => {
            await ds.getTitle(selectedTitle(), async function (data) {
                console.log(data);
                title(data);
                if (data.awards !== null) {
                    await getTitlePoster(data.awards);
                }
            })};

        let getTitlePoster = async (_url) => {
            await ds.getPoster(_url);
        };
        
    return {
        selectedTitle,
        titleRating,
        getTitleRating,
        crew,
        getTitleCrew,
        title,
        getSingleTitle
    }})