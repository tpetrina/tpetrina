import * as React from "react"
import { renderToString } from "react-dom/server"
import { createServerRenderer, RenderResult } from "aspnet-prerendering"
import { AppContainer } from "react-hot-loader"
import { StaticRouter } from "react-router"

import { routes } from "./routes"
import { store } from "./components/api"

export default createServerRenderer(params => {
  return new Promise<RenderResult>((resolve, reject) => {
    const basename = params.baseUrl.substring(0, params.baseUrl.length - 1) // Remove trailing slash
    const urlAfterBasename = params.url.substring(basename.length)

    const routerContext: any = {}
    const app = (
      <StaticRouter
        basename={basename}
        context={routerContext}
        location={params.location.path}
        children={routes}
      />
    )
    renderToString(app)

    // If there's a redirection, just send this information back to the host application
    if (routerContext.url) {
      resolve({ redirectUrl: routerContext.url })
      return
    }

    // Once any async tasks are done, we can perform the final render
    // We also send the redux store state, so the client can continue execution where the server left off
    let x = JSON.stringify(params, null, 2)
    params.domainTasks.then(() => {
      resolve({
        html: renderToString(app),
        globals: { initialState: store }
      })
    }, reject) // Also propagate any errors back into the host application
  })
})
