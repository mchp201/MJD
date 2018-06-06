import React, { PureComponent, Fragment } from 'react';
import { connect } from 'dva';
import moment from 'moment';
import {Row,Col,Card,Form,Input,Select,Icon,Button,Dropdown,Menu,InputNumber,DatePicker,Modal,message,Badge,Divider,
} from 'antd';
import StandardTable from 'components/StandardTable';
import PageHeaderLayout from '../../layouts/PageHeaderLayout';
import styles from './TableList.less';


const FormItem = Form.Item;
//定义弹出窗体
const CreateForm = Form.create()(props => {
    const { modalVisible, form, handleAdd, handleModalVisible } = props;
    const okHandle = () => {
      form.validateFields((err, fieldsValue) => {
        if (err) return;
        form.resetFields();
        handleAdd(fieldsValue);
      });
    };
    const formItemLayout = {
        labelCol: {
          xs: { span: 24 },
          sm: { span: 7 },
        },
        wrapperCol: {
          xs: { span: 24 },
          sm: { span: 12 },
          md: { span: 10 },
        },
      };
    return (
      <Modal
        title="新建用户"
        visible={modalVisible}
        onOk={okHandle}
        onCancel={() => handleModalVisible()}
      >
        <FormItem {...formItemLayout} label="姓名">
            {form.getFieldDecorator('Name', {
                rules: [{ required: true, message: '请输入姓名' }],
            })(<Input placeholder="你叫什么" />)}
        </FormItem>
        <FormItem {...formItemLayout} label="电话">
            {form.getFieldDecorator('TeleNum', {
                rules: [{ required: true, message: '请输入电话',}],
            })(<Input placeholder="电话是多少" />)}
        </FormItem>
      </Modal>
    );
  });

//链接Model
@connect(({ users, loading }) => ({
  users,
  loading: loading.models.users,
}))

//运行代码，创建弹层
@Form.create()

//主类
export default class Users extends PureComponent {
  state = {
    modalVisible: false,
    expandForm: false,
    selectedRows: [],
    formValues: {},
  };

  //新建按钮的响应事件，弹出窗体
  handleModalVisible = flag => {
    this.setState({
      modalVisible: !!flag,
    });
  };

  handleAdd = fields => {
    this.props.dispatch({
      type: 'users/add',
      payload: {
        Name: fields.Name,
        TeleNum: fields.TeleNum,
      },
    });

    message.success('添加成功');
    this.setState({
      modalVisible: false,
    });
  };

  //表格翻页、排序方法
  handleStandardTableChange = (pagination, filtersArg, sorter) => {
    const { dispatch } = this.props;
    const { formValues } = this.state;

    const filters = Object.keys(filtersArg).reduce((obj, key) => {
      const newObj = { ...obj };
      newObj[key] = getValue(filtersArg[key]);
      return newObj;
    }, {});

    const params = {
      currentPage: pagination.current,
      pageSize: pagination.pageSize,
      ...formValues,
      ...filters,
    };
    if (sorter.field) {
      params.sorter = `${sorter.field}_${sorter.order}`;
    }

    dispatch({
      type: 'users/fetch',
      payload: params,
    });
  };

  //页面加载完毕， 绑定数据方法
  componentDidMount() {
    const { dispatch } = this.props;
    dispatch({
      type: 'users/fetch',
      payload: {
        pageSize: 5,
        currentPage: 1
      },
    });
  }

  //页面构成
  render() {
    const { users: { data }, loading } = this.props;
    const { selectedRows, modalVisible } = this.state;

    const columns = [
      {
        title: '编号',
        dataIndex: 'id',
      },
      {
        title: '描述',
        dataIndex: 'name',
      },
      {
        title: '年龄',
        dataIndex: 'teleNum',
      },
    ];

    const parentMethods = {
        handleAdd: this.handleAdd,
        handleModalVisible: this.handleModalVisible,
    };

    return (
      <PageHeaderLayout title="查询表格">
        <Card bordered={false}>
          <div className={styles.tableList}>
            <div className={styles.tableListOperator}>
              <Button icon="plus" type="primary" onClick={() => this.handleModalVisible(true)}>
                新建
              </Button>
            </div>
            <StandardTable
              selectedRows={selectedRows}
              loading={loading}
              data={data}
              columns={columns}
              onChange={this.handleStandardTableChange}
            />
          </div>
        </Card>
        <CreateForm {...parentMethods} modalVisible={modalVisible} />
      </PageHeaderLayout>
    );
  }
}
