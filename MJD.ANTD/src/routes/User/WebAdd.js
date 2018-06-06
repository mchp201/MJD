import React, { Component } from 'react';
import { connect } from 'dva';
import { routerRedux, Link } from 'dva/router';
import { Form, Input, Button, Select, Row, message, Col, Popover, Progress } from 'antd';
import styles from './WebAdd.less';

const FormItem = Form.Item;
const { Option } = Select;
const InputGroup = Input.Group;

@connect(({ webadd, loading }) => ({
  webadd,
  loading: loading.models.submit,
}))

@Form.create()
export default class WebAdd extends Component {
  state = {
    count: 0,
    confirmDirty: false,
    visible: false,
    help: '',
  };

  // componentWillReceiveProps(nextProps) {
  //   // const account = this.props.form.getFieldValue('mail');
  //   if (nextProps.register.status === 'ok') {
  //     this.props.dispatch(
  //       routerRedux.push({
  //         pathname: '/user/webadd-result',
  //         state: {
            
  //         },
  //       })
  //     );
  //   }
  // }

  componentWillUnmount() {
    clearInterval(this.interval);
  }

  handleSubmit = e => {
    e.preventDefault();
    this.props.form.validateFields({ force: true }, (err, values) => {
      if (!err) {
        this.props.dispatch({
          type: 'webadd/submit',
          payload: {
            ...values,
          },
        });
      }
      message.success('添加成功');
    });
  };

  render() {
    const { form } = this.props;
    const { getFieldDecorator } = form;
    return (
      <div className={styles.main}>
        <h3>申请页面</h3>
        <Form onSubmit={this.handleSubmit}>
          <FormItem>
            {getFieldDecorator('UName', {
              rules: [
                {
                  required: true,
                  message: '请输入姓名！',
                },
                {
                  pattern: /^.{2,10}$/,
                  message: '请输入正确的姓名字符！',
                },
              ],
            })(<Input size="large" placeholder="姓名" />)}
          </FormItem>
          <FormItem>
            {getFieldDecorator('UCardid', {
              rules: [
                {
                  required: true,
                  message: '请输入身份证号！',
                },
                {
                  pattern: /^[1-9]\d{5}(19|20)\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$/,
                  //pattern: /^\d{17}[0-9Xx]$/,
                  message: '请输入正确的身份证号！',
                },
              ],
            })(<Input size="large" placeholder="身份证号" />)}
          </FormItem>
          <FormItem>
              {getFieldDecorator('UTelenum', {
                rules: [
                  {
                    required: true,
                    message: '请输入手机号！',
                  },
                  {
                    pattern: /^1\d{10}$/,
                    message: '手机号格式错误！',
                  },
                ],
              })(<Input size="large" placeholder="11位手机号" />)}
          </FormItem>
          <FormItem>
            <Button
              size="large"
              className={styles.submit}
              type="primary"
              htmlType="submit"
            >
              提交
            </Button>
          </FormItem>
        </Form>
      </div>
    );
  }
}
