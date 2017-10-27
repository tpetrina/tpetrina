import * as React from "react"
import { RouteComponentProps } from "react-router"

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
  state = {
    text: ""
  }

  login = () => {
    this.setState({ text: "Login..." })
    fetch("/account/login", {
      method: "POST",
      credentials: "same-origin"
    })
      .then(() => this.setState({ text: "Logged in" }))
      .catch(e => {
        this.setState({ text: "Login error: " + JSON.stringify(e) })
      })
  }

  logout = () => {
    this.setState({ text: "Logout..." })
    fetch("/account/logout", {
      method: "POST",
      credentials: "same-origin"
    })
      .then(() => this.setState({ text: "Logged out" }))
      .catch(e => {
        this.setState({ text: "Logout error: " + JSON.stringify(e) })
      })
  }

  fetch = () => {
    this.setState({ text: "Fetching..." })
    fetch("/api/private", {
      credentials: "same-origin"
    })
      .then(r => r.json())
      .then(data => {
        this.setState({ text: "Fetched..." + JSON.stringify(data) })
      })
      .catch(e => {
        this.setState({ text: "Error: " + JSON.stringify(e) })
      })
  }

  public render() {
    return (
      <div className="container">
        <br />
        <div className="form-group">
          <button className="btn btn-primary" onClick={this.login}>
            Login
          </button>
          <button className="btn btn-warning" onClick={this.logout}>
            Logout
          </button>

          <button className="btn btn-default" onClick={this.fetch}>
            Fetch
          </button>

          <pre>{this.state.text}</pre>
        </div>
      </div>
    )
  }
}
