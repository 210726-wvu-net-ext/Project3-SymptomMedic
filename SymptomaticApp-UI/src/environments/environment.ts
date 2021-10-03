// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  auth: {
    domain: 'LhGqAr3DtrpgsUr9KtW53YcUFS4VLeYH',
    clientId:'dev-8lq-w1e6.us.auth0.com',
    redirectUri: window.location.origin,
  },
};

export const authDomain = 'LhGqAr3DtrpgsUr9KtW53YcUFS4VLeYH';
export const authClientId = 'dev-8lq-w1e6.us.auth0.com';
export const baseUrl = `https://localhost:44391/api/`;
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
