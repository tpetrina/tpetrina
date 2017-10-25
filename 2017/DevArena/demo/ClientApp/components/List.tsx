import * as React from "react"
import { RouteComponentProps } from "react-router"

interface Item {
  id: number
  name: string
}

interface Props {
  item: Item
}

const Row = ({ item }: Props) => (
  <tr>
    <td>{item.id}</td>
    <td>{item.name}</td>
  </tr>
)

interface State {
  items: Item[]
}

class List extends React.Component<{} & RouteComponentProps<{}>, State> {
  state: State = {
    items: []
  }

  async componentDidMount() {
    let response = await fetch("/api/list")
    let data = await response.json()
    this.setState({ items: data })
  }

  render() {
    return (
      <div>
        <h2>List</h2>
        <table className="table table-striped table-hover">
          <thead>
            <tr>
              <th>Id</th>
              <th>Name</th>
            </tr>
          </thead>
          <tbody>
            {this.state.items.map(item => <Row key={item.id} item={item} />)}
          </tbody>
        </table>
      </div>
    )
  }
}

export default List
