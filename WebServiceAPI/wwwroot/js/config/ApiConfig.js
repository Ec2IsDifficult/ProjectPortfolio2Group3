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

    // api/user/rate
    let ApiPath2 = API_server + "/" + "api/user/";
    let ApiUserRate = ApiPath2 + "rate";

    return {
        ApiUserLogin,
        ApiUserRegister,
        ApiUserRecover,
        ApiUserUpdateEmail,
        ApiUserLogout,

        ApiUserRate
    }
});