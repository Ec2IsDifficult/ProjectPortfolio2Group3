define([], () => {

    let API_http = "http";
    let API_domain = "localhost";
    let API_port = "5000";
    let API_ver = "v1";

    let API_server = API_http + "://" + API_domain + ":" + API_port;

    let ApiPath = API_server + "/" + "api/" + API_ver + "/";

    let ApiUserLogin = ApiPath + "user/login";

    let ApiUserRegister = ApiPath + "user/register";

    let ApiUserRecover = ApiPath + "user/password";

    let ApiUserUpdateEmail = ApiPath + "user/email";

    let ApiUserLogout = ApiPath + "user/logout";

    let ApiUserRate = ApiPath + "user/rate";

    let ApiUserGetReviews = ApiPath + "user/reviews";

    return {
        ApiUserLogin,
        ApiUserRegister,
        ApiUserRecover,
        ApiUserUpdateEmail,
        ApiUserLogout,

        ApiUserRate,
        ApiUserGetReviews
    }
});