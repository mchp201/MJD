import { routerRedux } from 'dva/router';
import { emssage } from 'antd';
import { addRule } from '../services/api';
import { getAdmin } from '../services/api';
import { query as queryUsers, queryCurrent } from '../services/user';

export default{
    namespace: 'admin',
    
    state: {

    },

    effects: {
        *submitForm1({ payload }, { call, put }){
            console.log('---------------------effects submitForm1:'+payload);
            console.log(payload);

            const clientsResponse = yield call(getAdmin, payload);
            console.log('---------------------yield call(getAdmin, payload):');
            console.log(clientsResponse);

            // const response = yield call(queryUsers);

            // console.log(response);

            yield put({
                type: 'submitForm',
                payload: payload,
            });
            
            //message.success('提交成功');
        },
    },

    reducers:{
        submitForm(state, { payload }) {
            console.log('---------------------reducers submitForm:' + state);
            console.log(state);
            console.log(payload);
            return {
                ...state,
                ...payload,
            };
        },
    },
};