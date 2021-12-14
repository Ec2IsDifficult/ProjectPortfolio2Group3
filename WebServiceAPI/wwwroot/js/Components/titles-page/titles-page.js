define(["knockout", "dataservice"],
    function (ko, ds) {
        return function (params) {
            let selectedTitle = ko.observable('tt1954874');

            let cast = ko.observable([]);
            let getCast = () => {

                ds.getCast(selectedTitle(), function (data) {
                    console.log(data.cast);
                    cast(data.cast);
                })
            };

            let titleRating = ko.observable();
            let checkVotes = ko.observable('False');

            let getTitleRating = () => {
                ds.getTitleRating(selectedTitle(), function (data) {
                    if (data.numVotes > 0) {
                        checkVotes('True');
                    }
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
            let getSingleTitle = async () => {
                await ds.getTitle(selectedTitle(), async function (data) {
                    console.log(data);
                    title(data);
                    if (data.awards !== null) {
                        await getTitlePoster(data.awards);
                    }
                })
            };

            let getTitlePoster = async (_url) => {
                await ds.getPoster(_url);
                getImgSize(_url);
            };

            let posterHeight = ko.observable();


            /**
             * Sourced from
             * https://stackoverflow.com/questions/106828/javascript-get-image-height
             */
            let getImgSize = function (imgSrc) {
                console.log(imgSrc)
                var newImg = new Image();
                newImg.addEventListener("load", function () {
                    posterHeight(this.naturalHeight);
                    //alert(this.naturalWidth + ' ' + this.naturalHeight);
                });
                newImg.src = imgSrc;
            };

            (function () {
                function refresh(element, valueAccessor) {
                    var val = ko.utils.unwrapObservable(valueAccessor());
                    var newImg = new Image();

                    newImg.src = val;
                    curHeight = newImg.height;
                    console.log(curHeight);
                }

                ko.bindingHandlers.getImgSize = {
                    init: refresh,
                    update: refresh
                }
            })();


            return {
                selectedTitle,
                titleRating,
                getTitleRating,
                crew,
                getTitleCrew,
                title,
                getSingleTitle,
                cast,
                getCast,
                checkVotes,
                getTitlePoster,

                getImgSize,
                posterHeight
            }
        }
    })