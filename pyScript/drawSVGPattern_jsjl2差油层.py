# my favourite XML library
from xml.etree import ElementTree as et
def drawSVG(case=1,saveSVGFileName='sample.svg'): 
    # create an SVG XML element (see the SVG specification for attribute details)
    doc = et.Element('svg', width='20', height='20', version='1.1', xmlns='http://www.w3.org/2000/svg')
    et.SubElement(doc, 'path', d='M 10 0 L 0 10',style="fill:none;stroke:red;stroke-width:1;" )
    et.SubElement(doc, 'path', d='M 20 0 L 0 20',style="fill:none;stroke:red;stroke-width:1;" )
    et.SubElement(doc, 'path', d='M 20 10 L 10 20',style="fill:none;stroke:red;stroke-width:1;" )

     
    # ElementTree 1.2 doesn't write the SVG file header errata, so do that manually
    f = open(saveSVGFileName, 'w')
    f.write('<?xml version=\"1.0\" standalone=\"no\"?>\n')
    f.write('<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\"\n')
    f.write('\"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">\n')
    f.write(et.tostring(doc))
    f.close()

if __name__ == "__main__":
    case="jsjl2"
    drawSVG(case,saveSVGFileName=str(case)+'.svg')
 


