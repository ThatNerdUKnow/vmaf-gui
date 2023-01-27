import type { AppProps } from "next/app";

import "bootstrap/dist/css/bootstrap.min.css"
// This default export is required in a new `pages/_app.js` file.
export default function MyApp({ Component, pageProps }: AppProps) {
  return <Component {...pageProps} />;
}
