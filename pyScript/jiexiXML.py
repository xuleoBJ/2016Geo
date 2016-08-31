# -*- coding: utf-8 -*-
import xml.etree.cElementTree as ET

tree = ET.ElementTree(file='dq.xml')

f = open('myfile','w')
for node in tree.iter('litho'):
    name = node.attrib.get('name')
    value = node.attrib.get('scale')
   # f.write("hello\n") 
    if name and value:
        print '  %s :: %s' % (name, value)
    else:
        print name
f.close()
