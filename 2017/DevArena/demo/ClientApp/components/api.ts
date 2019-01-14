import { fetch, addTask } from "domain-task"

export const store = {
  list: []
}

export function getList() {
  let fetchTask = fetch("/api/list")
    .then(r => r.json())
    .then(data => (store.list = data))
  addTask(fetchTask)
  return fetchTask
}
