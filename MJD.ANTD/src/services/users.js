import { stringify } from 'qs';
import request from '../utils/request';



export async function queryUsers(params) {
  return request(`http://127.0.0.1:5000/api/admin/list?${stringify(params)}`);
}

export async function addUsers(params) {
  console.log("service-users-add");
  return request('http://127.0.0.1:5000/api/admin/add', {
    method: 'POST',
    body: {
      ...params,
      method: 'add',
    },
  });
}