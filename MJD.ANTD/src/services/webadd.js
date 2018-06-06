import { stringify } from 'qs';
import request from '../utils/request';


export async function webaddsubmit(params) {
  return request('http://127.0.0.1:5000/api/webadd/add', {
    method: 'POST',
    body: {
      ...params,
      method: 'add',
    },
  });
}