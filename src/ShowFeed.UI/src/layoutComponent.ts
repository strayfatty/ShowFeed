import './layoutComponent.css';
import * as m from 'mithril';

const LayoutComponent: m.FactoryComponent<any> = function () {
  return {
    view: render
  };

  function render(vnode: m.Vnode<any>) {
    return [
      m('header', { class: 'nav' }, [
        m('div', { class: 'nav-brand' }, 'ShowFeed'),
        m('div', { class: 'nav-menu' }, [
          m('div', { class: 'nav-left' }, [
            m('div', { class: 'nav-items' }, [
              renderLink('/series', 'Series'),
              renderLink('/follows', 'Follows')
            ])
          ]),
          m('div', { class: 'nav-right' }, [
            m('div', { class: 'nav-items' }, [
              renderLink('/login', 'Login')
            ])
          ])
        ])
      ]),
      m('main', { class: 'main' }, vnode.children)
    ];
  }
};

function renderLink(href: string, text: string): m.Vnode {
  var attributes = {
    class: 'nav-item',
    href: href,
    oncreate: m.route.link,
  };

  if (m.route.get().indexOf(href) === 0) {
    attributes.class += ' nav-item-active';
  }

  return m('a', attributes, text);
}

export default LayoutComponent;